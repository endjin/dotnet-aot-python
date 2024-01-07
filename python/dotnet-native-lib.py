import sys
from ctypes import *

architecture = sys.argv[1]
extension = 'dll' if architecture =="win-x64" else 'so'

dotnetnativelib = cdll.LoadLibrary(f"./artefacts/{architecture}/daeta.utils.{extension}")
dotnetnativelib.multiply.argtypes = [c_int, c_int]
dotnetnativelib.multiply.restype = c_int

print(f"20 x 24 = {dotnetnativelib.multiply(20, 24)}")