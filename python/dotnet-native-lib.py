import sys
from ctypes import *

architecture = sys.argv[1]

dotnetnativelib = cdll.LoadLibrary(f"./artefacts/{architecture}/daeta.utils.dll")
dotnetnativelib.multiply.argtypes = [c_int, c_int]
dotnetnativelib.multiply.restype = c_int

print(dotnetnativelib.multiply(20, 24))