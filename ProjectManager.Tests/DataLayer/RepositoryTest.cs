using Moq;
using NUnit.Framework;
using ProjectManager.DataLayer;
using ProjectManager.DataLayer.Repository;
using ProjectManager.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjectManager.Tests.DataLayer
{
    [TestFixture]
    public class RepositoryTest
    {
        [Test]
        public void When_GetAll_VerifyResults()
        {
            // Arrange
            var testList = Tasks;

            var dbSetMock = new Mock<DbSet<Task>>();
            dbSetMock.As<IQueryable<Task>>().Setup(x => x.Provider).Returns
                                                 (testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Task>>().Setup(x => x.Expression).
                                                 Returns(testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Task>>().Setup(x => x.ElementType).Returns
                                                 (testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Task>>().Setup(x => x.GetEnumerator()).Returns
                                                 (testList.AsQueryable().GetEnumerator());

            var context = new Mock<ProjectManagerContext>();
            context.Setup(x => x.Set<Task>()).Returns(dbSetMock.Object);

            // Act
            var repository = new Repository<Task>(context.Object);
            var result = repository.GetAll();

            // Assert
            Assert.AreEqual(testList, result.ToList());

            repository.Dispose();
        }

        [Test]
        public void When_GetById_Then_VerifyTaskDetails()
        {
            // Arrange
            var taskObject = GetTask();

            var context = new Mock<ProjectManagerContext>();
            var dbSetMock = new Mock<DbSet<Task>>();

            context.Setup(x => x.Set<Task>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(taskObject);

            // Act
            var repository = new Repository<Task>(context.Object);
            repository.Get(1);

            // Assert
            context.Verify(x => x.Set<Task>());
            dbSetMock.Verify(x => x.Find(It.IsAny<int>()));
        }

        [Test]
        public void When_InsertNewTask_Then_VerifyTaskInserted()
        {
            var taskObject = GetTask();

            var context = new Mock<ProjectManagerContext>();
            var dbSetMock = new Mock<DbSet<Task>>();
            context.Setup(x => x.Set<Task>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Add(It.IsAny<Task>())).Returns(taskObject);

            // Act
            var repository = new Repository<Task>(context.Object);
            repository.Add(taskObject);

            //Assert
            context.Verify(x => x.Set<Task>());
            dbSetMock.Verify(x => x.Add(It.Is<Task>(y => y == taskObject)));
        }

        [Test]
        public void When_DeleteTask_Then_VerifyTaskDeleted()
        {
            // Arrange
            var taskObject = GetTask();

            var context = new Mock<ProjectManagerContext>();
            var dbSetMock = new Mock<DbSet<Task>>();
            context.Setup(x => x.Set<Task>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Remove(It.IsAny<Task>())).Returns(taskObject);

            // Act
            var repository = new Repository<Task>(context.Object);
            repository.Remove(taskObject);

            //Assert
            context.Verify(x => x.Set<Task>());
            dbSetMock.Verify(x => x.Remove(It.Is<Task>(y => y == taskObject)));
        }

        [Test]
        public void When_TaskSearched_Then_VerifyResults()
        {
            var testList = Tasks;

            var searchList = testList.Where(x => x.TaskId == 1);

            var dbSetMock = new Mock<DbSet<Task>>();
            dbSetMock.As<IQueryable<Task>>().Setup(x => x.Provider).Returns
                                                       (testList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<Task>>().Setup(x => x.Expression).Returns
                                                       (testList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<Task>>().Setup(x => x.ElementType).Returns
                                                       (testList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<Task>>().Setup(x => x.GetEnumerator()).Returns
                                                       (testList.AsQueryable().GetEnumerator());

            var context = new Mock<ProjectManagerContext>();
            context.Setup(x => x.Set<Task>()).Returns(dbSetMock.Object);

            var repository = new Repository<Task>(context.Object);

            var result = repository.Find(x => x.TaskId == 1);

            Assert.AreEqual(searchList, result.ToList());
        }

        public static Task GetTask()
        {
            return new Task()
            {
                TaskName = "Task 15",
                Priority = 13,
                StartDate = new DateTime(2009, 10, 01),
                EndDate = new DateTime(2019, 10, 01)
            };
        }

        public static List<Task> Tasks = new List<Task>()
        {
            new Task()
            {
                TaskId = 1,
                TaskName = "Task 1",
                Priority = 3,
                StartDate = new DateTime(2009,10,01),
                EndDate = new DateTime(2019,10,01),
                TaskStatus = new TaskStatus() { Id = 1 },
                TaskStatusId =1
            },
            new Task()
            {
                TaskId = 2,
                TaskName = "Task 2",
                Priority = 5,
                StartDate = new DateTime(2009,10,01),
                EndDate = new DateTime(2019,10,01),
                TaskStatus = new TaskStatus() { Id = 1 },
                TaskStatusId =1
            },
            new Task()
            {
                TaskId = 3,
                TaskName = "Task 3",
                Priority = 10,
                StartDate = new DateTime(2009,10,01),
                EndDate = new DateTime(2019,10,01),
                TaskStatus = new TaskStatus() { Id = 1 },
                TaskStatusId =1
            }
        };
    }
}
