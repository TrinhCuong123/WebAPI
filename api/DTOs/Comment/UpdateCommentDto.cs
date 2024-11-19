using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Comment{
  public class UpdateCommentRequestDto{
    [Required]
    [MinLength(5, ErrorMessage = "Title must be 5 characters")]
    [MaxLength(256, ErrorMessage = "Title can not be over 256 characters")]
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
  }
}