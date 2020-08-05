using System.Collections.Generic;
using System.Linq;
using Algorithm.Inheritance;
using Xunit;

namespace Algorithm.Tests.Inheritance
{
    public class AggregationTests
    {
        [Fact]
        public void SummingAggregation_Produces_Sum()
        {
            var aggregator = new SummingAggregator(_measurements);

            var result = aggregator.Aggregate();

            Assert.Equal(107, result.X);
            Assert.Equal(30, result.Y);
        }

        [Fact]
        public void AveragingAggregator_Produces_Average()
        {
            var aggregator = new AveragingAggregator(_measurements);

            var result = aggregator.Aggregate();

            Assert.Equal(35, result.X);
            Assert.Equal(10, result.Y);
        }

        [Fact]
        public void LowPassAveragingAggregator_Applies_Filter()
        {
            var aggregator = new LowPassAveragingAggregator(_measurements);

            var result = aggregator.Aggregate();

            Assert.Equal(3, result.X);
            Assert.Equal(12, result.Y);            
        }

        /// Uncomment this test and make it pass reusing as much code as 
        /// possible from other classes that are available in the Inheritance folder
        [Fact]
        public void HighPassSummingAggregator_Applies_Filter()
        {                
            var aggregator = new HighPassSummingAggregator(_measurements);

            var result = aggregator.Aggregate();

            Assert.Equal(105, result.X);
            Assert.Equal(15, result.Y);
        }
        
        [Fact]
        public void LowPassSummingAggregator_Applies_Filter()
        {
            var aggregator = new LowPassSummingAggregator(_measurements);

            var result = aggregator.Aggregate();

            Assert.Equal(7, result.X);
            Assert.Equal(25, result.Y);
        }

        private readonly Measurement[] _measurements = new[]
        {
            new Measurement { X = 5, Y = 10},
            new Measurement { X = 2, Y = 15},
            new Measurement { X = 100, Y = 5}                  
        };
    }

    public class LowPassSummingAggregator : SummingAggregator
    {
        public LowPassSummingAggregator(IEnumerable<Measurement> measurements) : base(measurements)
        {
        }

        protected override IEnumerable<Measurement> FilterMeasurements(IEnumerable<Measurement> measurements)
        {
            return measurements.Where(m => m.X < 100 && m.Y < 100); 
        }
    }
}