using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymNotes.Doubles;

namespace GymNotes
{
    public class ExerciseSpy
    {
        private static List<ExerciseSpy> _items = new List<ExerciseSpy>();

        public string Name { get; private set; }
        public enum ExerciseType { Weighted, Unweigted, Distance }
        public ExerciseType Type;
        public string Instruction;
        public enum MuscleGroup { Back, Abs, Biceps, Chest, Forearm, Glutes, LowerLeg, Shoulder, Triceps, UpperLeg }
        public List<MuscleGroup> EnvolvedGroups { get; private set; }

        public ExerciseSpy(string name, ExerciseType type, List<MuscleGroup> groups, string instructions)
        {
            Name = name;
            Type = type;
            EnvolvedGroups = groups;
            Instruction = instructions;
        }

        private static Spy _spy = new Spy();
        public static List<MethodCall> Calls => _spy.Calls;

        public static void ResetSpy()
        {
            _spy = new Spy();
        }

        public static bool TryAddExcercise(string name, ExerciseType type, List<MuscleGroup> groups, string instructions = "")
        {
            if (String.IsNullOrEmpty(name) || type == null)
                return false; // TODO: empty fields message 
            if (_items.Any(e => e.Name.Equals(name)))
                return false;// TODO: existing name message 
            _spy.Add(name);
            _items.Add(new ExerciseSpy(name, type, groups, instructions));
            return true;
        }
        public static bool TryAddExcercise(ExerciseSpy exercise)
        {
            return TryAddExcercise(exercise.Name, exercise.Type, exercise.EnvolvedGroups, exercise.Instruction);
        }
        public bool TryEdit(string name)
        {
            if (String.IsNullOrEmpty(name))
                return false; // TODO: empty fields message 
            if (_items.Any(e => e.Name.Equals(name)))
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

        public static List<ExerciseSpy> SelectByGroup(List<MuscleGroup> groups)
        {
            if (groups == null || groups.Count == 0)
                return _items; // TODO: empty fields message
            var result = new List<ExerciseSpy>(_items);
            foreach (var muscleGroup in groups)
            {
                result.RemoveAll(e => !e.EnvolvedGroups.Contains(muscleGroup));
            }
            return result;
        }

        public static ExerciseSpy GetByName(string name)
        {
            var result = _items.Find(ex => String.Equals(ex.Name, name));
            if(result == null)
            {
                //throw new KeyNotFoundException();
            }
            else
            {
                _spy.Request(name);
            }
            return result;
        }

        public static bool Remove(ExerciseSpy exercise)
        {
            var res = _items.Remove(exercise);
            if(res)
                _spy.Remove(exercise.Name);
            return res;
        }
        public static bool Remove(string name)
        {
            return Remove(GetByName(name));
        }
        public static void RemoveAll()
        {
            foreach (var exercise in _items)
            {
                _spy.Remove(exercise.Name);
            }
             _items.Clear();
        }
        public static int GetCount()
        {
            return _items.Count;
        }
    }
}
