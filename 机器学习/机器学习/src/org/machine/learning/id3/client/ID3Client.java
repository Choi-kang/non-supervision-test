package org.machine.learning.id3.client;

import java.io.IOException;
import java.util.List;
import java.util.Map;

import org.machine.learning.id3.core.ID3Core;
import org.machine.learning.id3.model.AttributeNode;
import org.machine.learning.id3.utils.DecisionTreeUtils;

public class ID3Client {

    public static void main(String[] args) throws IOException {
        new ID3Client().start();
    }
    
    private void start() throws IOException {
        List<List<String>> currentData = DecisionTreeUtils.getTrainingData("./data/weather.txt");
        ID3Core core = new ID3Core();
        createDecisionTree(core, currentData);
    }
    
    private void createDecisionTree(ID3Core core, List<List<String>> currentData) {
        Map<String, Double> maxIGMap = core.maxInformationGain(currentData);
        AttributeNode rootNode = new AttributeNode(maxIGMap.keySet().iterator().next());
        setAttributeNodeStatus(core, currentData, rootNode);
        DecisionTreeUtils.showDecisionTree(rootNode, "");
    }
    
    /**
     * 设置特征属性节点的分支及子节点
     * 
     * @param core
     * @param currentData
     * @param rootNode
     */
    private void setAttributeNodeStatus(ID3Core core, List<List<String>> currentData, AttributeNode rootNode) {
        List<String> attributeBranchList = DecisionTreeUtils.getAttributeBranchList(currentData, rootNode.getAttributeName());
        int attributeIndex = DecisionTreeUtils.getAttributeIndex(currentData.get(0), rootNode.getAttributeName());
        
        for (String attributeBranch : attributeBranchList) {
            List<List<String>> splitAttributeDataList = DecisionTreeUtils.splitAttributeDataList(currentData, attributeBranch, attributeIndex);
            buildDecisionTree(core, attributeBranch, splitAttributeDataList, rootNode);
        }
    }
    
    /**
     * 构建 ID3 决策树
     * 
     * @param core
     * @param attributeBranch
     * @param splitAttributeDataList
     * @param node
     */
    private void buildDecisionTree(ID3Core core, String attributeBranch, List<List<String>> splitAttributeDataList, AttributeNode node) {
        Map<String, Double> maxIGMap = core.maxInformationGain(splitAttributeDataList);
        
        String attributeName = maxIGMap.keySet().iterator().next();
        double maxIG = maxIGMap.get(attributeName);
        if (maxIG == 0.0) {
            List<String> singleLineData = splitAttributeDataList.get(splitAttributeDataList.size() - 1);
            
            AttributeNode leafNode = new AttributeNode(singleLineData.get(singleLineData.size() - 1));
            leafNode.setLeaf(true);
            leafNode.setParentStatus(attributeBranch);
            node.addChildNodes(leafNode);
            return;
        }
        
        AttributeNode attributeNode = getNewAttributeNode(attributeName, attributeBranch, node);
        
        setAttributeNodeStatus(core, splitAttributeDataList, attributeNode);
    }
    
    private AttributeNode getNewAttributeNode(String attributeName, String attributeBranch, AttributeNode node) {
        AttributeNode attributeNode = new AttributeNode(attributeName);
        attributeNode.setParentStatus(attributeBranch);
        node.addChildNodes(attributeNode);
        
        return attributeNode;
    }
}
