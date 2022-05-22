using System;
using System.ComponentModel;
using System.Diagnostics;

namespace OpenSubtitleEditor.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {

            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmAbout m_frmAbout;

            public frmAbout frmAbout
            {
                [DebuggerHidden]
                get
                {
                    m_frmAbout = Create__Instance__(m_frmAbout);
                    return m_frmAbout;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmAbout))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmAbout);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmLicense m_frmLicense;

            public frmLicense frmLicense
            {
                [DebuggerHidden]
                get
                {
                    m_frmLicense = Create__Instance__(m_frmLicense);
                    return m_frmLicense;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmLicense))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmLicense);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmMain m_frmMain;

            public frmMain frmMain
            {
                [DebuggerHidden]
                get
                {
                    m_frmMain = Create__Instance__(m_frmMain);
                    return m_frmMain;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmMain))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmMain);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmPreviewSettings m_frmPreviewSettings;

            public frmPreviewSettings frmPreviewSettings
            {
                [DebuggerHidden]
                get
                {
                    m_frmPreviewSettings = Create__Instance__(m_frmPreviewSettings);
                    return m_frmPreviewSettings;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmPreviewSettings))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmPreviewSettings);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmUnknownFormat m_frmUnknownFormat;

            public frmUnknownFormat frmUnknownFormat
            {
                [DebuggerHidden]
                get
                {
                    m_frmUnknownFormat = Create__Instance__(m_frmUnknownFormat);
                    return m_frmUnknownFormat;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmUnknownFormat))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmUnknownFormat);
                }
            }

        }


    }
}