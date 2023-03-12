using Logic.Interfaces;
using Logic.Models;
using Logic.Storage;

namespace Logic.Classes;

internal class Service : IService
{
    private readonly IReminderRepository _repository;

    public Service(IReminderRepository repository)
    {
        _repository = repository;
    }

    public void SaveReminder(ReminderDto reminder)
    {
        _repository.Save(reminder);
    }
}
