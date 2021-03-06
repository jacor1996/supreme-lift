﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IWorkoutRepository
    {
        IEnumerable<Workout> GetWorkouts();

        IEnumerable<Workout> GetWorkouts(User user);

        Workout FindWorkout(int id);

        void AddWorkout(Workout workout);

        void DeleteWorkout(Workout workout);

        User FindUser(string userName);
    }
}
