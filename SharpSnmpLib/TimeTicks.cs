﻿using System;
using System.Globalization;

namespace Lextm.SharpSnmpLib
{
    /// <summary>
    /// TimeTicks type.
    /// </summary>
    /// <remarks>Represents SNMP TimeTicks type.</remarks>
    public sealed class TimeTicks : ISnmpData, IEquatable<TimeTicks>
    {
        private Counter32 _count;
        
        /// <summary>
        /// Creates a <see cref="TimeTicks"/> instance with a specific count.
        /// </summary>
        /// <param name="count">Count</param>
        [CLSCompliant(false)]
        public TimeTicks(uint count)
        {
            _count = new Counter32(count);
        }
        
        /// <summary>
        /// Creates a <see cref="TimeTicks"/> instance with raw bytes.
        /// </summary>
        /// <param name="raw">Raw bytes</param>
        public TimeTicks(byte[] raw)
        {
            _count = new Counter32(raw);
        }
        
        /// <summary>
        /// Returns an <see cref="Int32"/> that represents the current <see cref="TimeTicks"/>
        /// </summary>
        /// <returns></returns>
        [CLSCompliant(false)]
        public uint ToUInt32()
        {
            return _count.ToUInt32();
        }

        /// <summary>
        /// Type code.
        /// </summary>
        public SnmpType TypeCode
        {
            get
            {
                return SnmpType.TimeTicks;
            }
        }
        
        /// <summary>
        /// Determines whether the specified <see cref="Object"/> is equal to the current <see cref="TimeTicks"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare with the current <see cref="TimeTicks"/>. </param>
        /// <returns><value>true</value> if the specified <see cref="Object"/> is equal to the current <see cref="TimeTicks"/>; otherwise, <value>false</value>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return Equals(this, obj as TimeTicks);
        }
        
        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current <see cref="TimeTicks"/>.</returns>
        public override int GetHashCode()
        {
            return _count.GetHashCode();
        }

        #region ISnmpData Members

        /// <summary>
        /// To byte format.
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            return ByteTool.ToBytes(SnmpType.TimeTicks, _count.GetRaw());
        }

        #endregion
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><value>true</value> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <value>false</value>.
        /// </returns>
        public bool Equals(TimeTicks other)
        {
            return Equals(this, other);
        }
        
        /// <summary>
        /// The equality operator.
        /// </summary>
        /// <param name="left">Left <see cref="TimeTicks"/> object</param>
        /// <param name="right">Right <see cref="TimeTicks"/> object</param>
        /// <returns>
        /// Returns <c>true</c> if the values of its operands are equal, <c>false</c> otherwise.</returns>
        public static bool operator ==(TimeTicks left, TimeTicks right)
        {
            return Equals(left, right);
        }
        
        /// <summary>
        /// The inequality operator.
        /// </summary>
        /// <param name="left">Left <see cref="TimeTicks"/> object</param>
        /// <param name="right">Right <see cref="TimeTicks"/> object</param>
        /// <returns>
        /// Returns <c>true</c> if the values of its operands are not equal, <c>false</c> otherwise.</returns>
        public static bool operator !=(TimeTicks left, TimeTicks right)
        {
            return !(left == right);
        }
        
        /// <summary>
        /// Returns a <see cref="String"/> that represents this <see cref="TimeTicks"/>.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToUInt32().ToString(CultureInfo.InvariantCulture);
        }
        
        /// <summary>
        /// The comparison.
        /// </summary> 
        /// <param name="left">Left <see cref="TimeTicks"/> object</param>
        /// <param name="right">Right <see cref="TimeTicks"/> object</param>
        /// <returns>
        /// Returns <c>true</c> if the values of its operands are not equal, <c>false</c> otherwise.</returns>
        public static bool Equals(TimeTicks left, TimeTicks right)
        {
            object lo = left as object;
            object ro = right as object;
            if (lo == ro)
            {
                return true;
            }

            if (lo == null || ro == null)
            {
                return false;
            }
            
            return left._count == right._count;
        }
    }
}