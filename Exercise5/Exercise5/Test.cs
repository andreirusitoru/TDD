using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Exercise5
{
    [TestFixture]
    class Test
    {
        [Test]
        public void ReviewerNameDefaultsToAnonymous()
        {
            Assert.That(new Review("Alien").ReviewerName == "Anonymous");
        }

        [Test]
        public void AverageOfDefaultReviewsIs3()
        {
            List<Review> reviews = new List<Review>()
            {
                new Review("Alien"),
                new Review("Alien"),
                new Review("Alien"),
            };
            Assert.AreEqual(3.0f, Report.GetAverageRating(reviews, "Alien"), 0.1f);
        }

        [Test]
        public void UnknownMovieAverageRatingIs0()
        {
            Assert.AreEqual(0f, Report.GetAverageRating(new List<Review>(), "Alien"), 0.1f);
        }

        [Test]
        public void NumberOfReviewsForRating()
        {
            List<Review> reviews = new List<Review>()
            {
                new Review("Alien", Rating.Five),
                new Review("Alien", Rating.Five),
                new Review("Alien", Rating.Five),
                new Review("Alien", Rating.Five),
                new Review("Alien", Rating.Five),
                new Review("Alien", Rating.Four),
                new Review("Alien", Rating.Four),
                new Review("Alien", Rating.Four),
                new Review("Alien", Rating.Four),
                new Review("Alien", Rating.Three),
                new Review("Alien", Rating.Three),
                new Review("Alien", Rating.Three),
                new Review("Alien", Rating.Two),
                new Review("Alien", Rating.Two),
                new Review("Alien", Rating.One),
            };

            Assert.AreEqual(5, Report.GetRatingHistogram(reviews, "Alien")[Rating.Five].Count);
        }

    }

    public enum Rating
    {
        One = 1,
        Two,
        Three,
        Four,
        Five
    }
    internal class Review
    {
        public string MovieName { get; }
        public string ReviewerName { get; }
        public Rating Rating { get; }

        public Review(string movieName, Rating rating = Rating.Three, string reviewerName = "Anonymous")
        {
            MovieName = movieName;
            Rating = rating;
            ReviewerName = reviewerName;
        }
    }

    internal static class Report
    {
        public static double GetAverageRating(IEnumerable<Review> reviews, string movieName)
        {
            var movieReviews = reviews.Where(y => y.MovieName.Equals(movieName, StringComparison.InvariantCulture));
            if (!movieReviews.Any())
            {
                return 0f;
            }

            return movieReviews.Average(x => (int) x.Rating);
        }

        public static Dictionary<Rating, List<Review>> GetRatingHistogram(IEnumerable<Review> reviews, string movieName)
        {
            return
                reviews.Where(y => y.MovieName.Equals(movieName, StringComparison.InvariantCulture))
                    .Aggregate(new Dictionary<Rating, List<Review>>(),
                        (d, review) =>
                        {
                            if (!d.ContainsKey(review.Rating)) d.Add(review.Rating, new List<Review>());

                            d[review.Rating].Add(review);
                            return d;
                        });

        }
    }
}
