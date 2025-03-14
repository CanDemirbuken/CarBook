﻿using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.BlogID);
            blog.Title = request.Title;
            blog.CoverImageUrl = request.CoverImageUrl;
            blog.CreatedDate = request.CreatedDate;
            blog.AuthorID = request.AuthorID;
            blog.CategoryID = request.CategoryID;

            await _repository.UpdateAsync(blog);
        }
    }
}
