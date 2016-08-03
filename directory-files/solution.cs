public int GetFileCount(string strDirectory){
  //get count from strDirectory
  string[] filesInDirectory = Directory.GetFiles(strDirectory);
  int fileCount = filesInDirectory.Length;
  
  //get counts from sub-directories
  var subDirectories = Directory.GetDirectories(strDirectory);
  foreach (string subDirectory in subDirectories) {
    fileCount += GetFileCount(subDirectory);
  }
  
  return fileCount;
}