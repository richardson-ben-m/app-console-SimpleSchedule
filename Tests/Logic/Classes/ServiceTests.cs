using Logic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Logic.Classes;

internal class ServiceTests
{
    private Service _service;

    [SetUp]
    public void SetUp()
    {
        _service = new Service();
    }

    [Test]
    public void SaveReminder_Runs_SavesReminder()
    {

    }
}
