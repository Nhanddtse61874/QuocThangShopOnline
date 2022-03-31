using AutoMapper;
using LogicHandler.DTO;
using MediatorHandler.RepositoryInterface;
using MediatR;
using Persistence.EnitityModel;

namespace LogicHandler.Handler.CategoryHandler
{
    #region Add Category
    public class AddCategoryRequest : IRequest
    {
        public CategoryDTO? CategoryDTO { get; set; }
    }

    public class AddCategoryHandler : HandlerBase, IRequestHandler<AddCategoryRequest, Unit>
    {
        private readonly ICategoryRepository _repository;

        public AddCategoryHandler(ICategoryRepository repository, IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(_mapper.Map<Category>(request.CategoryDTO));
            return await Task.FromResult(Unit.Value);
        }
    }
    #endregion

    #region Update Category
    public class UpdateCategoryRequest : IRequest
    {
        public CategoryDTO? CategoryDTO { get; set; }
    }

    public class UpdateCategoryHandler : HandlerBase, IRequestHandler<UpdateCategoryRequest, Unit>
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryHandler(ICategoryRepository repository, IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            await _repository.ModifyAsync(_mapper.Map<Category>(request.CategoryDTO));
            return await Task.FromResult(Unit.Value);
        }
    }
    #endregion

    #region Delete Category
    public class DeleteCategoryRequest : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCategoryHandler : HandlerBase, IRequestHandler<DeleteCategoryRequest, Unit>
    {
        private readonly ICategoryRepository _repository;

        public DeleteCategoryHandler(ICategoryRepository repository, IMapper mapper) : base(mapper)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return await Task.FromResult(Unit.Value);
        }
    }
    #endregion
}
