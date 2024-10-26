namespace LinkDev.Talabat.Dashboard.Helpers
{
	public class PictureSettings
	{
		public static string UploadFile(IFormFile file, string folderName)
		{
			// 1. get folder path
			var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroor\\images", folderName);

			// 2. set file name unique
			var fileName = Guid.NewGuid() + file.FileName;

			// 3. get file path
			var filePath = Path.Combine(folderPath, fileName);

			// 4. create stream to filepath
			var fs = new FileStream(filePath, FileMode.Create);

			// 5. copy file to the stream
			file.CopyTo(fs);

			// 6. return filename
			return Path.Combine("images\\products", fileName);
		}

		public static void DeleteFile(string folderName, string fileName)
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroor\\images", folderName, fileName);

			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}
		}
	}
}
