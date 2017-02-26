using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prg3Opdrachten
{
    class Opgave2
    {
        ////zie Blackboard voor opdrachten uitleg

        //Opgave 2. Er staan k mensen in een rij (queue).
        //De mensen worden in volgorde genummerd van 1,2,3,...,k 
        //als je vooraankomt bij het loket wordt je in tweeën gesplitst en sluit je achteraan. 
        //wie wordt als nummer n behandelt (staat vooraan in de rij).
        //je moet dus n-1 mensen behandelen, en dan staat de n-de vooraan in de rij

        //Optioneel: je kan dit ook uitrekenen zonder gebruik te maken van een queue
        // er bestaat een formule om dit in een keer uitterekenen geven n en k. 
        // De optionele vraag is, bedenk deze formule en maak hiervoor een programma.

        //Voorbeeld
        //k = 4, n = 3  (test1)
        //q = 1 2 3 4           n=1  ==> 1
        //q = 2 3 4 1 1         n=2  ==> 2  
        //q = 3 4 1 1 2 2       n=3  ==> 3  (antwoord)

        //k = 4, n = 5  (test2)
        //q = 4 1 1 2 2 3 3     n=4 ==> 4
        //q = 1 1 2 2 3 3 4 4   n=5 ==> 1   (antwoord)
        //q = 1 2 2 3 3 4 4 1 1 n=6 ==> 1
        //etc

        public int DoubleQueueProblem(int k, int n)
        {
            IQueue<int> people = QueueFactory.CreateQueue<int>();
            throw new NotImplementedException();
        }

        [Test]
        public void TestDoubleQueueProblem1()
        {
            {
                int person = DoubleQueueProblem(4, 3);
                Assert.AreEqual(3, person);
            }

            {
                int person = DoubleQueueProblem(4, 5);
                Assert.AreEqual(1, person);
            }

            {
                int person = DoubleQueueProblem(4, 6);
                Assert.AreEqual(1, person);
            }

            {
                int person = DoubleQueueProblem(4, 7);
                Assert.AreEqual(2, person);
            }

            {
                int person = DoubleQueueProblem(4, 8);
                Assert.AreEqual(2, person);
            }

            {
                int person = DoubleQueueProblem(5, 9);
                Assert.AreEqual(2, person);
            }
        }
    }
}
