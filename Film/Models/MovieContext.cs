﻿using Microsoft.EntityFrameworkCore;

namespace Film.Models
{
    public class MovieContext: DbContext
    {
        //DbSet<Movie> Movie is a property that represents the collection of al Movie objects
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Genre>().HasData(
                new Genre() { GenreId ="D", Name = "Drama"},
                new Genre() {GenreId = "c", Name = "Comedy"},
                new Genre() {GenreId = "A", Name = "Action"},
                new Genre() {GenreId = "H", Name = "Horror"},
                new Genre() {GenreId = "M", Name  = "Musical"},
                new Genre() {GenreId = "R", Name = "Romance" },
                new Genre() {GenreId = "S", Name = "Sci-Fi" }

                );

            modelBuilder.Entity<Movie>().HasData(
                new Movie() { MovieId = 1, Name = "The Godfather", Year =1972, Rating = 5, GenreId ="D"},
                new Movie() { MovieId = 2, Name ="Casablanca", Year = 1942, Rating = 4, GenreId = "D"},
                new Movie() { MovieId = 3, Name ="The Matrix", Year = 1999, Rating = 4, GenreId = "A"}
                );
        }
    }
}
