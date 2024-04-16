namespace Task4;

public class SearchWeight
{
    //returns
    // - array with one element with target weight
    // - array with two elements; weights that gives in sum target sum 
    // - if no solution return empty array
    public static int[] Search(int[] weights, int targetWeight)
    {
        //check if weights contains targetWeight
        for (int i = 0; i < weights.Length; i++)
            if (weights[i] == targetWeight)
                return [weights[i]];

        //Check if there is any two weight that give sum equal target weight
        for (var i = 0; i < weights.Length - 1; i++)
            for (var j = i + 1; j < weights.Length; j++)
                if (weights[i] + weights[j] == targetWeight)
                    return [weights[i], weights[j]];

        //If no solution found return empty array
        return [];
    }
}
