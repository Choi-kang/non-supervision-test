package org.machine.learning.id3.utils;

import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.StringTokenizer;

import org.core.utils.files.FileReadUtils;
import org.machine.learning.id3.model.AttributeNode;

/**
 * <p>
 * 构建 ID3 决策树时用到的工具类
 * </p>
 * Create Date: 2016年6月22日
 * Last Modify: 2016年6月22日
 * 
 * @author <a href="http://weibo.com/u/5131020927">Q-WHai</a>
 * @see <a href="http://blog.csdn.net/lemon_tree12138">http://blog.csdn.net/lemon_tree12138</a>
 * @version 0.0.1
 */
public class DecisionTreeUtils {

    /**
     * 读取训练数据
     * 
     * @param dataFilePath
     * @return
     * @throws IOException
     */
    public static List<List<String>> getTrainingData(String dataFilePath) throws IOException {
        List<List<String>> result = new ArrayList<>();
        List<String> fileAllLines = FileReadUtils.readLines(dataFilePath);
        
        StringTokenizer tokenizer = null;
        for (String singleLine : fileAllLines) {
            tokenizer = new StringTokenizer(singleLine);
            List<String> lineData = new ArrayList<>();
            while (tokenizer.hasMoreTokens()) {
                lineData.add(tokenizer.nextToken());
            }
            result.add(lineData);
        }
        
        return result;
    }
    
    /**
     * 打印 ID3 决策树
     * 
     * @param node
     * @param prefix
     */
    public static void showDecisionTree(AttributeNode node, String prefix) {
        if (node == null) {
            return;
        }
        System.out.println(prefix + (node.getParentStatus() == null ? "" : node.getParentStatus() + "->") + node.getAttributeName());
        
        List<AttributeNode> children = node.getChildNodes();
        if (children == null) {
            return;
        }
        prefix += "\t";
        for (AttributeNode child : children) {
            showDecisionTree(child, prefix);
        }
    }
    
    /**
     * 获得某一个属性在原数据中所处的列索引
     * 
     * @param attributeNames
     * @param attribute
     * @return
     */
    public static int getAttributeIndex(List<String> attributeNames, String attribute) {
        int attributeIndex = 0;
        
        for (String attributeName : attributeNames) {
            if (attribute.equals(attributeName)) {
                break;
            }
            attributeIndex++;
        }
        
        return attributeIndex;
    }
    
    /**
     * 获得某一个属性下，各个分支的状态信息
     * Example: {Rainy={No=2, Yes=3}, Overcast={Yes=4}, Sunny={No=3, Yes=2}}
     * 
     * @param currentData
     * @param attributeIndex
     * @return
     */
    public static Map<String, Map<String, Integer>> getAttributeStatusMap(List<List<String>> currentData, int attributeIndex) {
        Map<String, Map<String, Integer>> attributeStatusMap = new HashMap<>();
        for (int rowIndex = 1; rowIndex < currentData.size(); rowIndex++) {
            List<String> singleData = currentData.get(rowIndex);
            String branch = singleData.get(attributeIndex);
            String status = singleData.get(singleData.size() - 1);
            
            Map<String, Integer> statusMap = null;
            if (attributeStatusMap.containsKey(branch)) {
                statusMap = attributeStatusMap.get(branch);
                if (statusMap.containsKey(status)) {
                    statusMap.put(status, statusMap.get(status) + 1);
                } else {
                    statusMap.put(status, 1);
                }
            } else {
                statusMap = new HashMap<>();
                statusMap.put(status, 1);
            }
            attributeStatusMap.put(branch, statusMap);
        }
        return attributeStatusMap;
    }
    
    /**
     * 从原数据中分离出特征属性 T 分支名称为 attribute 的所有子数据列表
     * 比如特征属性 T = OutLook，分支名称 attribute = Sunny
     * 
     * @param currentData
     * @param branch
     * @param attributeIndex
     * @return
     */
    public static List<List<String>> splitAttributeDataList(List<List<String>> currentData, String branch, int attributeIndex) {
        List<List<String>> result = new ArrayList<>();
        result.add(getSplitAttributeList(currentData.get(0), attributeIndex));
        
        for (int rowIndex = 1; rowIndex < currentData.size(); rowIndex++) {
            List<String> singleLineData = currentData.get(rowIndex);
            if (singleLineData.get(attributeIndex).equals(branch)) {
                result.add(getSplitAttributeList(singleLineData, attributeIndex));
            }
        }
        
        return result;
    }
    
    /**
     * 获得特征属性为 attribute 的所有分支列表
     * 
     * @param currentData
     * @param attributeIndex
     * @return
     */
    public static List<String> getAttributeBranchList(List<List<String>> currentData, String attribute) {
        List<String> attributeStatusList = new ArrayList<>();
        int attributeIndex = getAttributeIndex(currentData.get(0), attribute);
        
        for (int rowIndex = 1; rowIndex < currentData.size(); rowIndex++) {
            List<String> singleData = currentData.get(rowIndex);
            String branch = singleData.get(attributeIndex);
            
            if (attributeStatusList.contains(branch)) {
                continue;
            } else {
                attributeStatusList.add(branch);
            }
        }
        return attributeStatusList;
    }
    
    // TODO -------------------------------------------- private separated line ----------------------------------------------
    
    /**
     * 添加特征属性名称列表（移除了当前已经计算过了的特征属性 T）
     * 后期处理，移除特征属性 T。因为后面的计算不再关联此特征属性
     * 
     * @param singleLineData
     * @param attributeIndex
     * @return
     */
    private static List<String> getSplitAttributeList(List<String> singleLineData, int attributeIndex) {
        List<String> result = new ArrayList<>();
        for (int index = 0; index < singleLineData.size(); index++) {
            if (index != attributeIndex) {
                result.add(singleLineData.get(index));
            }
        }
        return result;
    }
}
