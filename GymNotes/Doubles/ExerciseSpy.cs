using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymNotes.Doubles;

namespace GymNotes
{
    public class Exercise
    {
        public static List<Exercise> Items = new List<Exercise>();

        public string Name { get; set; }
        public enum ExerciseType { Weighted, Unweigted, Distance }
        public ExerciseType Type;
        public string Instruction;
        public enum MuscleGroup { Back, Abs, Biceps, Chest, Forearm, Glutes, LowerLeg, Shoulder, Triceps, UpperLeg }
        public List<MuscleGroup> EnvolvedGroups { get; private set; }

        public Exercise(string name, ExerciseType type, List<MuscleGroup> groups, string instructions)
        {
            Name = name;
            Type = type;
            EnvolvedGroups = groups;
            Instruction = instructions;
        }

        public Exercise()
        {
            
        }
        public static bool TryAddExcercise(string name, ExerciseType type, List<MuscleGroup> groups, string instructions = "")
        {
            if (String.IsNullOrEmpty(name) || type == null)
                return false; // TODO: empty fields message 
            if (Items.Any(e => e.Name.Equals(name)))
                return false;// TODO: existing name message 
            Items.Add(new Exercise(name, type, groups, instructions));
            return true;
        }
        public static bool TryAddExcercise(Exercise exercise)
        {
            return TryAddExcercise(exercise.Name, exercise.Type, exercise.EnvolvedGroups, exercise.Instruction);
        }
        public bool TryEdit(string name)
        {
            if (String.IsNullOrEmpty(name))
                return false; // TODO: empty fields message 
            if (Items.Any(e => e.Name.Equals(name)))
                return false;
            Name = name;
            return true;
        }
        public bool TryEdit(List<MuscleGroup> groups)
        {
            if (groups == null || groups.Count == 0)
                return false; // TODO: empty fields message 
            EnvolvedGroups = groups;
            return true;
        }

        public static List<Exercise> SelectByGroup(List<MuscleGroup> groups)
        {
            if (groups == null || groups.Count == 0)
                return Items; // TODO: empty fields message
            var result = new List<Exercise>(Items);
            foreach (var muscleGroup in groups)
            {
                result.RemoveAll(e => !e.EnvolvedGroups.Contains(muscleGroup));
            }
            return result;
        }

        public static Exercise GetByName(string name)
        {
            var result = Items.Find(ex => String.Equals(ex.Name, name));
            if(result == null)
            {
                //throw new KeyNotFoundException();
            }
            return result;
        }

        public static bool Remove(Exercise exercise)
        {
            var res = Items.Remove(exercise);
            return res;
        }
        public static bool Remove(string name)
        {
            return Remove(GetByName(name));
        }
        public static void RemoveAll()
        {
             Items.Clear();
        }
        public static int GetCount()
        {
            return Items.Count;
        }

        public static void Load()
        {
            Items.Add(new Exercise() {Name = "Squats" });
            Items.Add(new Exercise() { Name = "Push Ups" });
            Items.Add(new Exercise() { Name = "Pull Ups" });
            Items.Add(new Exercise() { Name = "Crunches" });
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
