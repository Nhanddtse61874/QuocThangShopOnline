﻿using AutoMapper;
using LogicHandler.DTO;
using LogicHandler.Handler.CategoryHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuocThangShopOnline.ViewModel;

namespace QuocThangShopOnline.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CategoryController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index() => View(_mapper.Map<List<CategoryViewModel>>(_mediator.Send(new GetAllCategoryRequest { }).Result));


        [HttpGet]
        public  IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            _mediator.Send(new AddCategoryRequest { CategoryDTO = _mapper.Map<CategoryDTO>(model)});
             return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) => View(_mapper.Map<CategoryViewModel>(_mediator.Send(new GetCategoryByIdRequest { Id = id}).Result));

        [HttpPost]
        public IActionResult Edit(CategoryViewModel model)
        {
            _mediator.Send(new UpdateCategoryRequest { CategoryDTO = _mapper.Map<CategoryDTO>(model)});
            return Redirect("Index");
        }
    }
}
