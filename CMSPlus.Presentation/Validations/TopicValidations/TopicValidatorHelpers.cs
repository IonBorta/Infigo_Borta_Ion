using CMSPlus.Services.Interfaces;
using CMSPlus.Domain.Models.TopicModels;

namespace CMSPlus.Presentation.Validations.TopicValidations;

public class TopicValidatorHelpers
{
    private readonly ITopicService _topicService;

    public TopicValidatorHelpers(ITopicService topicService)
    {
        _topicService = topicService;
    }

    public async Task<bool> IsSystemNameUnique(string systemName, CancellationToken token)
    {
        var topic = await _topicService.GetBySystemName(systemName);
        return topic == null;
    }

    public async Task<bool> IsSystemNameUniqueEdit(TopicEditModel topic, CancellationToken token)
    {
        var topicBySystemName = await _topicService.GetBySystemName(topic.SystemName);
        var topicById = await _topicService.GetById(topic.Id);
        return topicBySystemName == null || topicBySystemName.Id == topicById.Id;
    }

    public bool IsUrl(string systemName)
    {
        return Uri.IsWellFormedUriString(systemName, UriKind.RelativeOrAbsolute);
    }
}