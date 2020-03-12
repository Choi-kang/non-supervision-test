package org.machine.learning.id3.utils;

public class CommonUtils {

    /**
     * 计算以 2 为底的对数
     * 
     * @param x
     * @return
     */
    public static double log2(double x) {
        return Math.log(x) / Math.log(2.0);
    }
}
