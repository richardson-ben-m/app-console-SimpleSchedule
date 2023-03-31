using Logic.Interfaces;
using Logic.Storage;
using Models;

namespace Logic.Classes;

internal class ReminderService : IReminderService
{
    private readonly IReminderRepository _repository;

    public ReminderService(IReminderRepository repository)
    {
        _repository = repository;
    }

    public void SaveReminder(Reminder reminder)
    {
        _repository.Save(reminder);
    }
}
