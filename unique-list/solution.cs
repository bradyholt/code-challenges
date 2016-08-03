public int[] simplify(int[] input){
    List<int> sortedUniqueList = new List<int>();
    
    if (input != null && input.Length > 0){
        //sort elements in-place (ascending)
        Array.Sort(input); 
    
        //add first element before grabbing unique values of the rest
        sortedUniqueOutput.Add(input[0]);
    
        for(int i=1; i<input.Length; i++){ //starting at second element!
            int current = input[i];
            int previous = input[i-1];
            
            if (current != previous) {
                //only add if not the same as previous value
                sortedUniqueOutput.Add(current);
            }
        }
    }
    
    int[] output = sortedUniqueList.ToArray();
    return output;
}