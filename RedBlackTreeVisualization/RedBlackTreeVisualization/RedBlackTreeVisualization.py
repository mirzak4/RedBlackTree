from math import radians
from pyclbr import Class
from tkinter.ttk import Style
import numpy as np # installed with matplotlib
import matplotlib.pyplot as plt
import json
import jsonpickle
import graphviz

def visualize_binary_tree(root):
    dot = graphviz.Digraph(strict=1)
    dot.node(str(root["Key"]))

    def add_nodes_edges(node):
        if node["Left"]:
            color = str(node["Left"]["Color"])
            fontcolor = "black";
            if (color == "Black"):
                fontcolor = "white"
            dot.node(str(node["Left"]["Key"]), style="filled", fillcolor=color, fontcolor=fontcolor)
            dot.edge(str(node["Key"]), str(node["Left"]["Key"]))
            add_nodes_edges(node["Left"])
        else:
            nillNodeName = str("NL") + str(node["Key"])
            dot.node(nillNodeName, shape = "point")
            dot.edge(str(node["Key"]), nillNodeName)
        if node["Right"]:
            color = str(node["Right"]["Color"])
            fontcolor = "black"
            if (color == "Black"):
                fontcolor = "white"
            dot.node(str(node["Right"]["Key"]), style="filled", fillcolor=color, fontcolor=fontcolor)
            dot.edge(str(node["Key"]), str(node["Right"]["Key"]))
            add_nodes_edges(node["Right"])
        else:
            nillNodeName = str("NR") + str(node["Key"])
            dot.node(nillNodeName, shape="point")
            dot.edge(str(node["Key"]), nillNodeName)

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
