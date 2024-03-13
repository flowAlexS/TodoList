﻿namespace Api.Models
{
    public class TodoTask
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public bool Completed { get; set; }
    }
}
