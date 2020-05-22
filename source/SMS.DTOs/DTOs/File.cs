﻿using System;
using System.Drawing;
using System.Net.Mime;

namespace SMS.DTOs.DTOs
{
    public class File : DtoBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public int Size { get; set; }
        public Byte[] ImageFile { get; set; }
    }
}
