package main;

import java.util.Random;
import java.util.TreeMap;

/**
 * Tests the speed of TreeMap data structure
 */
public class Test {

    /**
     * Entry point of the program
     *
     * @param args arguments for the program
     */
    public static void main(String[] args) {
        new Test();
    }

    // characters to be used when constructing random strings
    private final char[] availableCharacters = new char[] {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'r', 's', 't', 'u', 'v', 'z'
    };

    // test will be performed for each of these numbers of elements
    private final int[] testSizes = new int[] {
            10000, 20000, 40000, 80000, 160000
    };

    // used to generate random index in availableCharacters array
    private final Random rand = new Random(2018);

    // map to be used for the test
    private final TreeMap<String, String> map = new TreeMap<>();

    /**
     * Class constructor
     */
    private Test() {
        for (int n = 0; n < testSizes.length; n++) {
            map.clear();

            String[] keys = generateStrings(testSizes[n]);
            String[] values = generateStrings(testSizes[n]);

            System.out.println("********** TEST #" + (n + 1) + ": " + testSizes[n] + " elements **********");

            // TEST PUT METHOD
            long startTime = System.currentTimeMillis();

            for (int i = 0; i < testSizes[n]; i++) {
                map.put(keys[i], values[i]);
            }

            long endTime = System.currentTimeMillis();
            long time = endTime - startTime;

            System.out.println("Put() took: " + time + " milliseconds");

            // TEST GET METHOD
            startTime = System.currentTimeMillis();

            for (int i = 0; i < testSizes[n]; i++) {
                map.get(keys[i]);
            }

            endTime = System.currentTimeMillis();
            time = endTime - startTime;

            System.out.println("Get() took: " + time + " milliseconds");

            // TEST REMOVE METHOD
            startTime = System.currentTimeMillis();

            for (int i = 0; i < testSizes[n]; i++) {
                map.remove(keys[i]);
            }

            endTime = System.currentTimeMillis();
            time = endTime - startTime;

            System.out.println("Remove() took: " + time + " milliseconds");

            // print a blank line so that the tests are separated a bit
            System.out.println();
        }
    }

    /**
     * Generates many random strings
     *
     * @param ammount ammount of strings to generate
     * @return array of strings
     */
    private String[] generateStrings(int ammount) {
        String[] data = new String[ammount];

        for (int i = 0; i < ammount; i++) {
            data[i] = generateRandomString(availableCharacters.length);
        }

        return data;
    }

    /**
     * Generates a random string of characters in availableCharacters array
     *
     * @param length length of the string
     * @return generated string
     */
    private String generateRandomString(int length) {
        String s = "";

        for (int i = 0; i < length; i++) {
            s += availableCharacters[rand.nextInt(availableCharacters.length)];
        }

        return s;
    }
}
