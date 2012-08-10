using NUnit.Framework;
using PrathameshKulkarni.GameOfLife;

namespace PrathameshKulkarni.GameOfLifeTests
{
    [TestFixture]
    public class OrganismTests
    {
        private Organism _organismInitializedAsAlive;
        private Organism _organismInitializedAsDead;

        [SetUp]
        public void SetUp()
        {
            _organismInitializedAsAlive = new Organism(true);
            _organismInitializedAsDead = new Organism(false);
        }

        [TearDown]
        public void TearDown()
        {
            _organismInitializedAsAlive = null;
            _organismInitializedAsDead = null;
        }

        [Test]
        public void Test_IsAlive_OrganismIsInitializedAsAlive_ReturnsIsAliveAsTrue()
        {
            var organism = new Organism(true);

            Assert.That(organism.IsAlive, Is.True, "An organism that is initialized as alive should have returned true");
        }

        public void Test_Neighbours_InitializedOrganizm_HasAtleastTwoNeighbours()
        {
        }
    }
}