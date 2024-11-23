using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Services.Interfaces;

namespace CMSPlus.Services.Services;

public class TopicService:ITopicService
{
    private readonly ITopicRepository _repository;
    private readonly ICommentRepository _commentRepository;

    public TopicService(ITopicRepository repository, ICommentRepository commentRepository)
    {
        _repository = repository;
        _commentRepository = commentRepository;
    }

    public async Task<TopicEntity> GetById(int id)
    {
        var entity =  await _repository.GetById(id);
        entity!.Comments = await _commentRepository.GetCommentsByTopicId(entity.Id);
        return entity;
    }
    
    public async Task<TopicEntity?> GetBySystemName(string systemName)
    {
        var entity =  await _repository.GetBySystemName(systemName);
        entity!.Comments = await _commentRepository.GetCommentsByTopicId(entity.Id);
        return entity;
    }

    public async Task<IEnumerable<TopicEntity>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task Create(TopicEntity entity)
    {
        await _repository.Create(entity);
    }

    public async Task Update(TopicEntity entity)
    {
        await _repository.Update(entity);
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
    }
}