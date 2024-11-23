using CMSPlus.Domain.Entities;

namespace CMSPlus.Services.Interfaces;

public interface ITopicService:IBasicService<TopicEntity>
{
    public Task<TopicEntity?> GetBySystemName(string systemName);

}