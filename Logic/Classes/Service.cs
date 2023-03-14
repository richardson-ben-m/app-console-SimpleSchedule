using Logic.Interfaces;
using Logic.Storage;
using Models;

namespace Logic.Classes;

internal class Service : IService
{
    private readonly IReminderRepository _repository;

    public Service(IReminderRepository repository)
    {
        _repository = repository;
    }

    public void SaveReminder(Reminder reminder)
    {
        _repository.Save(reminder);
    }
}
