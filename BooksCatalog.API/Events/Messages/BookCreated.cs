﻿using BooksCatalog.Infra.Messaging;

namespace BooksCatalog.API.Events.Messages
{
    public class BookCreated : EventMessage
    {
        public int BookId { get; set; }

        public BookCreated(int bookId) => BookId = bookId;

        public override string QueueName() => "book-created";
    }
}