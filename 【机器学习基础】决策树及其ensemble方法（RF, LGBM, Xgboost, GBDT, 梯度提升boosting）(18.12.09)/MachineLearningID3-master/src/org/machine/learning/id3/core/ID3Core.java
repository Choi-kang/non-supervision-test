package org.machine.learning.id3.core;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;

import org.machine.learning.id3.utils.CommonUtils;
import org.machine.learning.id3.utils.DecisionTreeUtils;

public class ID3Core {

    /**
     * 计算所有特征属性的信息增益中的最大值
     * 
     * @param currentData
     */
    public Map<String, Double> maxInformationGain(List<List<String>> currentData) {
        Map<String, Double> maxIGMap = new HashMap<>();
        List<String> attributeNames = getAttributeNames(currentData);
        
        double maxIG = -1;
        String maxIGAttributeName = "";
        for (String attributeName : attributeNames) {
            double currentIG = currentAttributeInformationGain(currentData, attributeName);
            if (maxIG < currentIG) {
                maxIG = currentIG;
                maxIGAttributeName = attributeName;
            }
        }
        
        maxIGMap.put(maxIGAttributeName, maxIG);
        return maxIGMap;
    }
    
    // TODO -------------------------------------------- private separated line ----------------------------------------------
    
    /**
     * 计算在特征属性为 attribute 时的信息增益
     * 
     * @param currentData
     * @param attribute
     * @return
     */
    private double currentAttributeInformationGain(List<List<String>> currentData, String attribute) {
        return currentEntropy(currentData) - currentAttributeEntropy(currentData, attribute);
    }
    
    /**
     * 获得所有的特征属性列表
     * 
     * @param currentData
     * @return
     */
    private List<String> getAttributeNames(List<List<String>> currentData) {
        List<String> attributeNames = new ArrayList<>();
        List<String> getAttributeNames = currentData.get(0);
        for (int attributeIndex = 1; attributeIndex < getAttributeNames.size() - 1; attributeIndex++) {
            attributeNames.add(getAttributeNames.get(attributeIndex));
        }
        
        return attributeNames;
    }
    
    /**
     * 计算当前状态下的总的信息熵
     * 
     * @param currentData
     * @return
     */
    private double currentEntropy(List<List<String>> currentData) {
        Map<String, Integer> map = getDistributeMap(currentData);
        int totalCount = currentData.size() - 1;
        
        double entropy = 0.0;
        Set<String> keySet = map.keySet();
        for (String key : keySet) {
            entropy -= ((1.0 * map.get(key) / totalCount) * CommonUtils.log2(1.0 * map.get(key) / totalCount));
        }
        
        return entropy;
    }
    
    /**
     * 计算当前状态下某一个属性的信息熵
     * 
     * @param currentData
     * @param attribute
     * @return
     */
    private double currentAttributeEntropy(List<List<String>> currentData, String attribute) {
        // 保存当前属性下的所有分支状态
        List<String> attributeNames = currentData.get(0);
        int totalCount = currentData.size() - 1;
        int attributeIndex = DecisionTreeUtils.getAttributeIndex(attributeNames, attribute);
        Map<String, Map<String, Integer>> attributeStatusMap = DecisionTreeUtils.getAttributeStatusMap(currentData, attributeIndex);
        
        return currentAttributeEntropy(attributeStatusMap, totalCount);
    }
    
    /**
     * 计算在特征属性 T 的条件下样本的条件熵
     * 
     * @param attributeStatusMap
     * @param totalCount
     * @return
     */
    private double currentAttributeEntropy(Map<String, Map<String, Integer>> attributeStatusMap, int totalCount) {
        Set<String> branchSet = attributeStatusMap.keySet();
        double conditionalEntropy = 0.0;
        for (String branch : branchSet) {
            double branchEntropy = currentBranchEntropy(attributeStatusMap.get(branch)); // 某一个分支的信息熵
            double branchProbability = currentBranchProbability(attributeStatusMap.get(branch), totalCount);
            conditionalEntropy += (branchEntropy * branchProbability);
        }
        
        return conditionalEntropy;
    }
    
    /**
     * 计算某一个状态的信息熵
     * 
     * @param statusMap
     * @return
     */
    private double currentBranchEntropy(Map<String, Integer> statusMap) {
        Set<String> statusSet = statusMap.keySet();
        int totalStatus = 0;
        for (String status : statusSet) {
            totalStatus += statusMap.get(status);
        }
        
        double entropy = 0.0;
        for (String status : statusSet) {
            entropy -= ((1.0 * statusMap.get(status) / totalStatus) * CommonUtils.log2(1.0 * statusMap.get(status) / totalStatus));
        }
        
        return entropy;
    }
    
    /**
     * 计算某一个状态的条件概率
     * 
     * @param statusMap
     * @param totalCount
     * @return
     */
    private double currentBranchProbability(Map<String, Integer> statusMap, int totalCount) {
        int statusSum = 0;
        Set<String> statusKeySet = statusMap.keySet();
        for (String statusKey : statusKeySet) {
            statusSum += statusMap.get(statusKey);
        }
        
        return 1.0 * statusSum / totalCount;
    }
    
    /**
     * 计算当前状态下的结果分布
     * 
     * @param currentData
     * @param map
     */
    private Map<String, Integer> getDistributeMap(List<List<String>> currentData) {
        Map<String, Integer> map = new HashMap<>();
        
        for (int rowIndex = 1; rowIndex < currentData.size(); rowIndex++) {
            List<String> singleData = currentData.get(rowIndex);
            String play = singleData.get(singleData.size() - 1);
            if (map.containsKey(play)) {
                map.put(play, map.get(play) + 1);
            } else {
                map.put(play, 1);
            }
        }
        
        return map;
    }
    
}
