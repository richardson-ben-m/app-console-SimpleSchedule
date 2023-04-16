using Logic.Interfaces;
using Logic.Storage;
using Models;

namespace Logic.Classes;

internal class ReminderCommandService : IReminderCommandService
{
    private readonly IReminderRepository _repository;

    public ReminderCommandService(IReminderRepository repository)
    {
        _repository = repository;
    }

    public void SaveReminder(Reminder reminder)
    {
        _repository.Save(reminder);
    }
}
