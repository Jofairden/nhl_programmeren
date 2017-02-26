using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prg3Opdrachten
{
    class Opgave3
    {
        ////zie Blackboard voor opdrachten uitleg

        //Palindrome checker. 
        //Schrijf een methode (Paldindroom) die gegeven een string bekijkt of het een palindroom betreft. 
        //Leestekens, spaties en case (kleine of hooddletters) moet je negeren. 
        //gebruik 1 Stack en 1 Queue.
        //tip: itereer 1 keer door de string!

        //De voorbeeld palindromen: http://home.wxs.nl/~avdw3b/palindr.html

        public bool Palindroom(string input)
        {
            IStack<char> s = StackFactory.CreateStack<char>();
            IQueue<char> q = QueueFactory.CreateQueue<char>();

            throw new NotImplementedException();
        }


        [Test]
        public void TestPalindroomStack()
        {
            Assert.AreEqual(true, Palindroom("leel"));
            Assert.AreEqual(true, Palindroom("lepel"));
            Assert.AreEqual(true, Palindroom("maannaam"));
            Assert.AreEqual(true, Palindroom("maandnaam"));

            Assert.AreEqual(false, Palindroom("lewael"));
            Assert.AreEqual(false, Palindroom("lepelt"));
            Assert.AreEqual(false, Palindroom("maannam"));
            Assert.AreEqual(false, Palindroom("mannaam"));

            Assert.AreEqual(false, Palindroom(""));
            Assert.AreEqual(false, Palindroom("  "));
            Assert.AreEqual(false, Palindroom(null));

            Assert.AreEqual(true, Palindroom("Baas, neem een racecar, neem een Saab."));
            Assert.AreEqual(true, Palindroom("Mooi dit idioom."));
            Assert.AreEqual(true, Palindroom("Mooie zeden in Ede zei oom."));
            Assert.AreEqual(true, Palindroom("Nelli plaatst op ene parterretrap ene pot staalpillen."));
            Assert.AreEqual(true, Palindroom("Daar eiste hy z'n ei en zy het sieraad."));
        }
    }
}
