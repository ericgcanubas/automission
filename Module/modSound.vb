﻿Module modSound

    Sub PlayBackgroundSoundFile()
        My.Computer.Audio.Play("C:\Waterfall.wav",
            AudioPlayMode.WaitToComplete)
    End Sub


End Module
