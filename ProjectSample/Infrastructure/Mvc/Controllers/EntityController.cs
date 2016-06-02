using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjectSample.Infrastructure.CommandBus;
using ProjectSample.Infrastructure.DataAccess;
using ProjectSample.Infrastructure.DataAccess.Queries;
using ProjectSample.Infrastructure.Domain.Base;
using ProjectSample.Infrastructure.Mvc.Models;
using ProjectSample.Infrastructure.NHibernate.Queries;

namespace ProjectSample.Infrastructure.Mvc.Controllers
{
    public abstract class EntityController<TEntity, TViewModel, TFieldModel, TIndexListItemModel, TKey> : Controller
        where TEntity : Entity<TKey>
        where TFieldModel : new()
        where TIndexListItemModel : class
    {
        protected readonly IMapper Mapper;
        protected readonly IRepository Repository;

        protected EntityController(IMapper mapper, IRepository repository)
        {
            if (mapper == null) throw new ArgumentNullException(nameof(mapper));
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            Mapper = mapper;
            Repository = repository;
        }

        protected virtual int ItemsPerPage => 10;

        public virtual ICommandBus Bus { get; set; }

        protected void SetError(string message)
        {
            TempData["Error"] = message;
        }

        protected void SetSuccess(string message)
        {
            TempData["Success"] = message;
        }

        protected virtual ActionResult RedirectAfterAction(TEntity entity)
        {
            return RedirectToAction("Details", new {entity.Id});
        }

        #region Index

        protected abstract IEnumerable<string> GetHeaders();

        public virtual ActionResult Index(int? page)
        {
            page = page ?? 1;

            var entities = FindEntities(page.Value);
            var indexItems = MapToIndexItems(entities);
            var indexModel = CreateIndexModel(indexItems);
            return CreateIndexResult(indexModel);
        }

        private ActionResult CreateIndexResult(EntityIndexModel model) => View(model);

        protected virtual IEnumerable<TEntity> FindEntities(int page)
        {
            var query = CreateQuery(page);
            return Repository.Query(query);
        }

        protected virtual IEnumerable<TIndexListItemModel> MapToIndexItems(IEnumerable<TEntity> entities)
            => Mapper.Map<IEnumerable<TEntity>, IEnumerable<TIndexListItemModel>>(entities);

        protected virtual EntityIndexModel CreateIndexModel(IEnumerable<TIndexListItemModel> items)
            => new EntityIndexModel
            {
                Headers = GetHeaders(),
                Items = items
            };

        protected virtual QueryObject<IEnumerable<TEntity>> CreateQuery(int page)
            => new GenericEntityQueryObject<TEntity, TKey>(page, ItemsPerPage);

        #endregion

        #region Details

        public virtual ActionResult Details(TKey id)
        {
            var entity = FindEntity(id);
            var model = MapToViewModel(entity);
            return CreateDetailsResult(model);
        }

        protected virtual TEntity FindEntity(TKey id) => Repository.Find<TEntity>(id);
        protected virtual TViewModel MapToViewModel(TEntity entity) => Mapper.Map<TViewModel>(entity);
        protected virtual ActionResult CreateDetailsResult(TViewModel model) => View(model);

        #endregion

        #region Create

        public virtual ActionResult Create()
        {
            var model = CreateFieldModel();
            return CreateCreateResult(model);
        }

        public virtual TFieldModel CreateFieldModel()
        {
            return new TFieldModel();
        }

        public virtual ActionResult CreateCreateResult(TFieldModel model) => View(model);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(TFieldModel fields)
        {
            if (!ModelState.IsValid)
            {
                SetError("There are some errors");
                return CreateCreateResult(fields);
            }

            var result = CreateCore(fields);
            if (!result.IsValid)
            {
                SetError(result.Message);
                return CreateCreateResult(fields);
            }

            SetSuccess(result.Message);
            return RedirectAfterAction(result.Entity);
        }

        protected virtual Result<TEntity, TFieldModel> CreateCore(TFieldModel fields)
        {
            var entity = MapFromFields(fields);
            SaveEntity(entity);
            return Result.Valid(entity, fields, $"{typeof (TEntity).Name} created");
        }

        protected virtual TEntity MapFromFields(TFieldModel fields) => Mapper.Map<TEntity>(fields);

        protected virtual void SaveEntity(TEntity entity) => Repository.Save(entity);

        #endregion

        #region Delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Delete(TKey id)
        {
            var entity = FindEntity(id);
            DeleteCore(entity);
            SetSuccess($"{typeof(TEntity).Name} deleted");
            return CreateDeleteResult();
        }

        protected virtual void DeleteCore(TEntity entity) => Repository.Delete(entity);

        protected virtual ActionResult CreateDeleteResult() => RedirectToAction("Index");

        #endregion

        #region Edit

        public virtual ActionResult Edit(TKey id)
        {
            var entity = FindEntity(id);
            var model = MapToFieldModel(entity);

            return CreateEditResult(model);
        }

        protected virtual TFieldModel MapToFieldModel(TEntity entity)
            => Mapper.Map<TFieldModel>(entity);

        protected virtual ActionResult CreateEditResult(TFieldModel model) => View(model);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(TKey id, TFieldModel fields)
        {
            if (!ModelState.IsValid)
            {
                SetError("There are some errors.");
                return CreateEditResult(fields);
            }

            var entity = FindEntity(id);
            var result = EditCore(fields, entity);

            if (!result.IsValid)
            {
                SetError(result.Message);
                return CreateEditResult(fields);
            }

            SetSuccess(result.Message);
            return RedirectAfterAction(entity);
        }

        protected virtual Result EditCore(TFieldModel fields, TEntity entity)
        {
            MapFromFields(fields, entity);
            SaveEntity(entity);
            return Result.Valid(entity, fields, $"{typeof (TEntity).Name} saved");
        }

        protected virtual void MapFromFields(TFieldModel fields, TEntity entity)
            => Mapper.Map(fields, entity);

        #endregion
    }

}