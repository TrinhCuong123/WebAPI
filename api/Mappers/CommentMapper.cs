using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Comment;
using api.DTOs.Stock;
using api.Models;

namespace api.Mappers{
  public static class CommentMapper{
    public static CommentDto ToCommentDto(this Comment commentModel){
      return new CommentDto{
        Id = commentModel.Id,
        Title = commentModel.Title,
        Content = commentModel.Content,
        CreatedOn = commentModel.CreatedOn,
        StockID = commentModel.StockID,
      };
    }

    public static Comment ToCommentFromCreate(this CreateCommentDTO commentDto, int stockId){
      return new Comment{
        Title = commentDto.Title,
        Content = commentDto.Content,
        StockID = stockId,
      };
    }
    
    public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto){
      return new Comment{
        Title = commentDto.Title,
        Content = commentDto.Content,
      };
    }
  }
}