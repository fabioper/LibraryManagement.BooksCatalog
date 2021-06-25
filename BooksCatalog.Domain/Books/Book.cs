﻿namespace BooksCatalog.Domain.Books
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public Status Status { get; set; }

        public void RentBook() => Status = Status.Rented;
    }
}