using Kanban.Database.Entities;
using Kanban.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kanban.Domain.Mappers
{
    public static class KanbanMapper
    {
        public static DBItemTask ToEntity(this ItemTask task)
        {
            return new DBItemTask
            {
                Id = task.Id,
                User = task.User.ToEntity(),
                Created = task.Created,
                Description = task.Description,
                Title = task.Title
            };
        }
        public static DBBacklogItem ToEntity(this BacklogItem backlogItem)
        {
            return new DBBacklogItem
            {
                Created = backlogItem.Created,
                Description = backlogItem.Description,
                EstimatedTime = backlogItem.EstimatedTime,
                Id = backlogItem.Id,
                Tasks = backlogItem.Tasks.Select(task => task.ToEntity()),
                Title = backlogItem.Title
            };
        }
        public static DBSprint ToEntity(this Sprint sprint)
        {
            return new DBSprint
            {
                AdditionalInformation = sprint.AdditionalInformation,
                BacklogItems = sprint.BacklogItems.Select(backlogItem => backlogItem.ToEntity()),
                EndDate = sprint.EndDate,
                Id = sprint.Id,
                SprintGoal = sprint.SprintGoal,
                StartDate = sprint.StartDate
            };
        }
        public static DBUser ToEntity(this User user)
        {
            return new DBUser
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname
            };
        }
        public static ItemTask ToModel(this DBItemTask task)
        {
            return new ItemTask
            {
                Created = task.Created,
                Description = task.Description,
                Id = task.Id,
                Title = task.Title,
                User = task.User.ToModel()
            };
        }
        public static BacklogItem ToModel(this DBBacklogItem backlogItem)
        {
            return new BacklogItem
            {
                Created = backlogItem.Created,
                Description = backlogItem.Description,
                EstimatedTime = backlogItem.EstimatedTime,
                Id = backlogItem.Id,
                Tasks = backlogItem.Tasks.Select(task => task.ToModel()),
                Title = backlogItem.Title
            };
        }
        public static Sprint ToModel(this DBSprint sprint)
        {
            return new Sprint
            {
                AdditionalInformation = sprint.AdditionalInformation,
                BacklogItems = sprint.BacklogItems.Select(backlogItem => backlogItem.ToModel()),
                EndDate = sprint.EndDate,
                Id = sprint.Id,
                SprintGoal = sprint.SprintGoal,
                StartDate = sprint.StartDate
            };
        }
        public static User ToModel(this DBUser user)
        {
            return new User
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname
            };
        }
    }
}
