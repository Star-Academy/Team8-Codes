package main.src.utils;

import java.util.*;


public class Prettifier {

    final static int MAX_ITEMS = 10;

    public static String prettify(HashSet<? extends Object> inputSet) {
        ArrayList<Object> itemList = new ArrayList<>(inputSet);
        StringBuilder out = new StringBuilder();
        if (itemList.size() <= MAX_ITEMS)
            collectItemStrings(itemList, out, 0, itemList.size());
        else {
            collectItemStrings(itemList, out, 0, MAX_ITEMS / 2);
            out.append("\t    ...\n");
            collectItemStrings(itemList, out, itemList.size() - 5, itemList.size());
        }
        return out.toString();
    }

    public static String prettify(HashMap<? extends Object, ? extends HashSet> inputMap){
        StringBuilder out = new StringBuilder();
        for(Object key : inputMap.keySet()){
            out.append(key + "\n");
            out.append(prettify(inputMap.get(key)));
        }
        return out.toString();
    }

    private static void collectItemStrings(ArrayList<Object> itemList, StringBuilder builder, int startIndex, int endIndex) {
        int maxSize = ("" + itemList.size()).length();
        for (int idx = startIndex; idx < endIndex; idx++)
            builder.append("\t" + leftPad("" + (idx + 1), maxSize) + ") " + itemList.get(idx) + "\n");
    }

    private static String leftPad(String s, int length) {
        if (s.length() >= length)
            return s;
        return s + multiply(" ", length - s.length());
    }

    private static String multiply(String s, int multiplier) {
        StringBuilder result = new StringBuilder();
        for (int i = 1; i <= multiplier; i++)
            result.append(s);
        return result.toString();
    }

}