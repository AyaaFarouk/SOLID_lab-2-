using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public interface Icreate
    {  
        void CreateSubTask();  
    }
    public interface Iassign
    {
        void AssignTask();
    }
    public interface Iwork
    {
        void WorkOnTask();
    }
//------------------------------------------------------------
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public void AssignTo(Developer developer)
        {
            Console.WriteLine($"Task '{Title}' assigned to {developer.Name}");
        }
    }

     public class Developer
    {
        public string Name { get; set; }

    }
//-------------------------------------------------------------------
    public class TeamLead : Icreate, Iassign, Iwork
    {
        public Task Task { get; }
        public Developer Develop { get; }

        public TeamLead(Task task, Developer develop)
        {
            Task = task;
            Develop = develop;
        }

        public void CreateSubTask()
        {
            Console.WriteLine("Subtask created by Team Lead.");
        }

        public void AssignTask()
        {
            Task.Title = "Merge and Deploy";
            Task.Description = "Task to merge and deploy sharing feature to develop";
            Task.AssignTo(Develop);
        }

        public void WorkOnTask()
        {
            Console.WriteLine("Team Lead is working on task.");
        }
    }



}


