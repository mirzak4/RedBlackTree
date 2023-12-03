from math import radians
import numpy as np # installed with matplotlib
import matplotlib.pyplot as plt
import json
import jsonpickle
import graphviz

def visualize_binary_tree(root):
    dot = graphviz.Digraph(strict=1)
    rootId = root["$id"]
    dot.node(str(rootId), label=str(root["Key"]), style="filled", fillcolor="Black", fontcolor="white")

    def add_nodes_edges(node):
        nodeId = node["$id"]
        print(str(node["Key"]))
        if not node["Left"]["IsNill"]:
            color = str(node["Left"]["Color"])
            fontcolor = "black";
            if (color == "Black"):
                fontcolor = "white"
            leftNodeId = node["Left"]["$id"]
            dot.node(str(leftNodeId), label=str(node["Left"]["Key"]), style="filled", fillcolor=color, fontcolor=fontcolor)
            dot.edge(str(nodeId), str(leftNodeId))
            add_nodes_edges(node["Left"])
        else:
            nillNodeName = str("NL") + str(nodeId)
            dot.node(nillNodeName, shape = "point")
            dot.edge(str(nodeId), nillNodeName)
        if not node["Right"]["IsNill"]:
            color = str(node["Right"]["Color"])
            fontcolor = "black"
            if (color == "Black"):
                fontcolor = "white"
            rightNodeId = node["Right"]["$id"]
            dot.node(str(rightNodeId), label=str(node["Right"]["Key"]), style="filled", fillcolor=color, fontcolor=fontcolor)
            dot.edge(str(nodeId), str(rightNodeId))
            add_nodes_edges(node["Right"])
        else:
            nillNodeName = str("NR") + str(nodeId)
            dot.node(nillNodeName, shape="point")
            dot.edge(str(nodeId), nillNodeName)

    add_nodes_edges(root)
    dot.render('binary_tree', view=True, format='png')

def main():
    import os
    os.environ["PATH"] += os.pathsep + 'D:/Program Files (x86)/Graphviz2.38/bin/'
    f = open("C:\\Users\\mirza.kadric\\NASP\\RedBlackTree\\RedBlackTree\\RedBlackTree\\Content\\rbt.json")
    data = json.load(f)
    # root = jsonpickle.decode(data)
    root = json.dumps(data)
    root = json.loads(root)
    # root = jsonpickle.loads(root)
    visualize_binary_tree(root)

main()
