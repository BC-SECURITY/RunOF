using System;
using System.Runtime.InteropServices;

namespace RunOF
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IMAGE_FILE_HEADER
    {
        public IMAGE_FILE_MACHINE Machine;
        public UInt16 NumberOfSections;
        public UInt32 TimeDateStamp;
        public UInt32 PointerToSymbolTable;
        public UInt32 NumberOfSymbols;
        public UInt16 SizeOfOptionalHeader;
        public UInt16 Characteristics;
    }
    public enum IMAGE_FILE_MACHINE : ushort
    {
        IMAGE_FILE_MACHINE_UNKNOWN = 0x0,
        IMAGE_FILE_MACHINE_I386 = 0x14c,
        IMAGE_FILE_MACHINE_AMD64 = 0x8664,
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IMAGE_SECTION_HEADER
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Name;
        public UInt32 PhysicalAddressVirtualSize;
        public UInt32 VirtualAddress;
        public UInt32 SizeOfRawData;
        public UInt32 PointerToRawData;
        public UInt32 PointerToRelocations;
        public UInt32 PointerToLinenumbers;
        public UInt16 NumberOfRelocations;
        public UInt16 NumberOfLinenumbers;
        public UInt32 Characteristics;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IMAGE_SYMBOL
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Name;
        public UInt32 Value;
        public IMAGE_SECTION_NUMBER SectionNumber;
        public IMAGE_SYMBOL_TYPE Type;
        public byte StorageClass;
        public byte NumberofAuxSymbols;
    }


    public enum IMAGE_SECTION_NUMBER : short
    {
        IMAGE_SYM_UNDEFINED = 0,
        IMAGE_SYM_ABSOLUTE = -1,
        IMAGE_SYM_DEBUG = -2,
    }

    public enum IMAGE_SYMBOL_TYPE : ushort
    {
        IMAGE_SYM_TYPE_NULL = 0x0,
        IMAGE_SYM_TYPE_VOID = 0x1,
        IMAGE_SYM_TYPE_CHAR = 0x2,
        IMAGE_SYM_TYPE_SHORT = 0x3,
        IMAGE_SYM_TYPE_INT = 0x4,
        IMAGE_SYM_TYPE_LONG = 0x5,
        IMAGE_SYM_TYPE_FLOAT = 0x6,
        IMAGE_SYM_TYPE_DOUBLE = 0x7,
        IMAGE_SYM_TYPE_STRUCT = 0x8,
        IMAGE_SYM_TYPE_UNION = 0x9,
        IMAGE_SYM_TYPE_ENUM = 0xA,
        IMAGE_SYM_TYPE_MOE = 0xB,
        IMAGE_SYM_TYPE_BYTE = 0xC,
        IMAGE_SYM_TYPE_WORD = 0xD,
        IMAGE_SYM_TYPE_UINT = 0xE,
        IMAGE_SYM_TYPE_DWORD = 0xF,
        IMAGE_SYM_TYPE_FUNC = 0x20, // A special MS extra
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IMAGE_RELOCATION
    {
        public UInt32 VirtualAddress;
        public UInt32 SymbolTableIndex;
        public IMAGE_RELOCATION_TYPE Type; // TODO this is architecture dependant

    }   

    public enum IMAGE_RELOCATION_TYPE : ushort
    {
        // Why does Microsoft list these in decimal for I386 and hex for AMD64?
        /* I386 relocation types */
        IMAGE_REL_I386_ABSOLUTE = 0,
        IMAGE_REL_I386_DIR16 = 1,
        IMAGE_REL_I386_REL16 = 2,
        IMAGE_REL_I386_DIR32 = 6,
        IMAGE_REL_I386_DIR32NB = 7,
        IMAGE_REL_I386_SEG12 = 9,
        IMAGE_REL_I386_SECTION = 10,
        IMAGE_REL_I386_SECREL = 11,
        IMAGE_REL_I386_TOKEN = 12,
        IMAGE_REL_I386_SECREL7 = 13,
        IMAGE_REL_I386_REL32 = 20,
    }
}