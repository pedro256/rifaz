"use client"

import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog"

import { Button } from "@/components/ui/button"
import { createContext, useContext, useState, ReactNode } from "react"

type DialogType = "default" | "success" | "error" | "warning"

type DialogOptions = {
  type?: DialogType
  title: string
  description?: string
  confirmText?: string
  cancelText?: string
}

type DialogContextType = {
  alert: (options: DialogOptions) => void
  confirm: (options: DialogOptions) => Promise<boolean>
  success: (options: DialogOptions) => void
  error: (options: DialogOptions) => void
}

const DialogContext = createContext<DialogContextType | null>(null)

export function DialogProvider({ children }: { children: ReactNode }) {
  const [open, setOpen] = useState(false)
  const [options, setOptions] = useState<DialogOptions | null>(null)
  const [resolver, setResolver] = useState<(value: boolean) => void>()

  function close() {
    setOpen(false)
    setOptions(null)
  }

  function alert(options: DialogOptions) {
    setOptions(options)
    setOpen(true)
  }

  function success(options: DialogOptions) {
    alert({ ...options, type: "success" })
  }

  function error(options: DialogOptions) {
    alert({ ...options, type: "error" })
  }

  function confirm(options: DialogOptions): Promise<boolean> {
    setOptions(options)
    setOpen(true)
    return new Promise((resolve) => {
      setResolver(() => resolve)
    })
  }

  function handleConfirm() {
    resolver?.(true)
    close()
  }

  function handleCancel() {
    resolver?.(false)
    close()
  }

  const colorMap = {
    default: "",
    success: "text-green-600",
    error: "text-red-600",
    warning: "text-yellow-600",
  }

  return (
    <DialogContext.Provider value={{ alert, confirm, success, error }}>
      {children}

      <Dialog open={open} onOpenChange={setOpen}>
        <DialogContent>
          <DialogHeader>
            <DialogTitle className={colorMap[options?.type || "default"]}>
              {options?.title}
            </DialogTitle>
            <DialogDescription>
              {options?.description}
            </DialogDescription>
          </DialogHeader>

          <DialogFooter>
            {resolver && (
              <Button variant="outline" onClick={handleCancel}>
                {options?.cancelText || "Cancelar"}
              </Button>
            )}
            <Button onClick={handleConfirm}>
              {options?.confirmText || "OK"}
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </DialogContext.Provider>
  )
}

export function useDialog() {
  const context = useContext(DialogContext)
  if (!context) {
    throw new Error("useDialog must be used within DialogProvider")
  }
  return context
}