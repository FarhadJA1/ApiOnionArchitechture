using AutoMapper;
using DomainLayer.Entities;
using RepoLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Book;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public Task CreateAsync(Book book)
        {
            if (book is null) throw new ArgumentNullException();
            return _bookRepository.CreateAsync(book);
        }

        

        public async Task<List<BookListDTO>> GetAll()
        {
            var model = await _bookRepository.GetAllAsync();
            return _mapper.Map<List<BookListDTO>>(model);
        }

        
    }
}
