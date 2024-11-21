using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository{
  public class CommentRepository: ICommentRepository{
    private readonly ApplicationDBContext _context;

    public CommentRepository(ApplicationDBContext context){
      _context = context;
    }

    public Task<List<Comment>> GetAllAsync(){
      return _context.Comment.ToListAsync();
    }

    public Task<Comment?> GetByIDAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Comment> CreateAsync(Comment commentModel){
      await _context.Comment.AddAsync(commentModel);
      await _context.SaveChangesAsync();
      return commentModel;
    }

    public async Task<Comment?> UpdateAsync(int id, Comment commentModel){
      var existsComment = await _context.Comment.FindAsync(id);
      if (existsComment == null) return null;
      existsComment.Title = commentModel.Title;
      existsComment.Content = commentModel.Content;
      await _context.SaveChangesAsync();
      return existsComment;
    }

    public async Task<Comment?> DeleteAsync(int id){
      var commentModel = await _context.Comment.FirstOrDefaultAsync(x => x.Id == id);
      if (commentModel == null) return null;
      _context.Comment.Remove(commentModel);
      await _context.SaveChangesAsync();
      return commentModel;
    }
  }
}