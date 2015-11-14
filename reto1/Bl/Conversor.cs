using System.Collections.Generic;
using System.Linq;

namespace reto1.Bl
{

    /// <summary>
    /// This class converts the input data structure into an output data structures
    /// </summary>
    public static class Conversor
    {

        /// <summary>
        /// Converts the specified input classes into the output classes.
        /// </summary>
        /// <param name="inputClasses">The input classes.</param>
        /// <returns>The output classes</returns>
        public static IEnumerable<OutputClass> Convert(IList<InputClass> inputClasses)
        {
            var axList = inputClasses.Where(x => x.Ax == true).ToList();
            var ayList = inputClasses.Where(x => x.Ay == true).ToList();
            var bxList = inputClasses.Where(x => x.Bx == true).ToList();
            var byList = inputClasses.Where(x => x.By == true).ToList();

            var groupA = Join(axList, ayList, "A");
            var groupB = Join(bxList, byList, "B");

            var outputList = groupA.Concat(groupB);

            return outputList;
        }


        /// <summary>
        /// Joins the specified lists.
        /// </summary>
        /// <param name="xList">The list with the propertie x active.</param>
        /// <param name="yList">The list with the propertie y active.</param>
        /// <param name="group">The group aplicable to each element.</param>
        /// <returns>The joined list</returns>
        private static IEnumerable<OutputClass> Join(IList<InputClass> xList, IList<InputClass> yList, string group)
        {
            var outputObject = new OutputClass()
            {
                ClassAB = group,
                Y = 0,
                X = 0
            };

            var countX = xList.Count();
            
            var countY = yList.Count();

            var count = countY > countX ? countY : countX;
            
            var array = Enumerable.Repeat(outputObject, count).ToArray();

            var iteratorX = new Iterator(xList);
            var iteratorY = new Iterator(yList);

            foreach (var outputClass in array)
            {
                outputClass.X = iteratorX.Next().Codigo;
                outputClass.Y = iteratorY.Next().Codigo;
                outputClass.ClassAB = group;
            }

            return array;
        }
    }
}
