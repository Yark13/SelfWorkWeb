using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUniversity.DataLayer;
using WebUniversity.DataLayer.Entity;
using WebUniversity.DataLayer.UnitOfWork;
using WebUniversity.DataLayer.UnitOfWork.Repository;

namespace WebUniversity.Controllers;

public class EntityController<T> : Controller where T : class, IEntity
{
    protected readonly ILogger<EntityController<T>> _logger;
    protected readonly IUnitOfWork<StateDbContext> _unitOfWork;
    protected readonly IMapper _mapper;
    protected readonly IRepository<T> _repository;

    protected string jsonData;
    protected dynamic jsonObject;

    public EntityController(ILogger<EntityController<T>> logger, IUnitOfWork<StateDbContext> unitOfWork, IMapper mapper)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = _unitOfWork.GetRepository<T>();

        jsonData = System.IO.File.ReadAllText("appsettings.json");
        jsonObject = JsonConvert.DeserializeObject(jsonData);
    }

    protected void Filter<U>(ref IQueryable<U> entities, string currentFilter, string searchString, ref int? pageNumber) where U : class, IEntity
    {
        if (searchString != null)
        {
            pageNumber = 1;
        }
        else
        {
            searchString = currentFilter;
        }

        ViewData["CurrentFilter"] = searchString;

        if (!String.IsNullOrEmpty(searchString))
        {
            var filteredEntities = entities.AsEnumerable().Where(e => e.Name.Contains(searchString));
            entities = entities.Where(c => filteredEntities.Contains(c));
        }
    }

    protected void SetEntitiesDepentedProperty<Ent, TKey>(
    List<T> dest,
    Func<T, TKey> destRecognitionKeySelector,
    Func<Ent, TKey> srcRecognitionKeySelector,
    Action<T, Ent> AssignValue) where Ent : class, IEntity
    {
        var src = _unitOfWork.GetRepository<Ent>().GetAll().OrderBy(srcRecognitionKeySelector);

        int startFrom = 0;

        foreach (var srcEntity in src)
        {
            AssignValueToEntitiesProperty(dest, ref startFrom,
                (destEntity) =>
                {
                    return destRecognitionKeySelector(destEntity).
                    Equals(srcRecognitionKeySelector(srcEntity));
                },
                (destEntity) => { AssignValue(destEntity, srcEntity); }); ;
        }
    }

    private void AssignValueToEntitiesProperty(List<T> entities, ref int i,
        Func<T, bool> isNeededEntity,
        Action<T> AssignValue)
    {
        for (; i < entities.Count; i++)
        {
            if (!isNeededEntity.Invoke(entities[i]))
            {
                return;
            }

            for (int j = i; j < entities.Count; j++)
            {
                AssignValue(entities[j]);

                if (!isNeededEntity.Invoke(entities[i]))
                {
                    i = j;

                    return;
                }
            }
        }
    }
}
