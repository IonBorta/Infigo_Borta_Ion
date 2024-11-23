using AutoMapper;
using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Models.CommentModels;
using CMSPlus.Domain.Models.TopicModels;
using CMSPlus.Services.Interfaces;
using CMSPlus.Services.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSPlus.Presentation.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCommentModel> _createCommentValidator;
        public CommentController(
                    ICommentService commentService,
                    IMapper mapper,
                    IValidator<CreateCommentModel> createCommentValidator,
                    ITopicService topicService
            )
        {
            _commentService = commentService;
            _mapper = mapper;
            _createCommentValidator = createCommentValidator;
            _topicService = topicService;
        }
        // GET: CommentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CommentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult DisplayByTopic(IEnumerable<CommentModel>? models)
        {
            return View(models);
        }

        // GET: CommentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCommentModel model)
        {
            try
            {
                var validationResult = await _createCommentValidator.ValidateAsync(model);
                if (!validationResult.IsValid)
                {
                    validationResult.AddToModelState(this.ModelState);
                    var topic = await _topicService.GetById(model.TopicId);
                    var topicToDisplay = _mapper.Map<TopicEntity,TopicDetailsModel>(topic);

                    // Pass the `CreateCommentModel` back to the partial view
                    ViewBag.CreateCommentModel = model;

                    // Return the Index view from the TopicController, passing the topics
                    return View("~/Views/Topic/Details.cshtml", topicToDisplay);
                }
                var commentEntity = _mapper.Map<CreateCommentModel, CommentEntity>(model);
                await _commentService.Create(commentEntity);
                return RedirectToAction("Details","Topic");
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return View(model);
            }
        }

        // GET: CommentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
