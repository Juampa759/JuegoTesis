﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class QuizDB : MonoBehaviour
{
    [SerializeField] private List<Question> m_questionList = null;

    private List<Question> m_backup = null;

    private void Awake()
    {
        m_backup = m_questionList;
    }

    public Question GetRandom(bool remove = true)
    {
        if (m_questionList.Count == 0)
            RestoreBackup();

        int index = UnityEngine.Random.Range(0, m_questionList.Count);

        if (!remove)
            return m_questionList[index];

        Question q = m_questionList[index];
        m_questionList.RemoveAt(index);

        return q;
    }

    private void RestoreBackup()
    {
        m_questionList = m_backup;
    }

}
