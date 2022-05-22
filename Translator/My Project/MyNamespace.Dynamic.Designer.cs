using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Translator.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {

            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmTranslator m_frmTranslator;

            public frmTranslator frmTranslator
            {
                [DebuggerHidden]
                get
                {
                    m_frmTranslator = Create__Instance__(m_frmTranslator);
                    return m_frmTranslator;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmTranslator))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmTranslator);
                }
            }

        }


    }
}